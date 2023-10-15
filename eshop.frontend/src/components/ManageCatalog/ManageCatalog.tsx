import React, { useEffect, useState } from 'react';
import { ICatalogBrandItem } from '../../models/catalogBrand.model';
import { ICatalogTypeItem } from '../../models/catalogType.model';
import { createCatalogBrand, getAllCatalogBrand } from '../../services/catalogBrand.service';
import { createCatalogType, getAllCatalogType } from '../../services/catalogType.service';
import { ICatalogItem } from '../../models/catalog.model';
import { createCatalog, getAllCatalog } from '../../services/catalog.service';
import { Button, Form, FormFeedback, FormGroup, Input, Label } from 'reactstrap';

export default function ManageCatalog() {
	const [catalog, setCatalog] = useState<ICatalogItem[]>([]);
	const [catalogBrand, setCatalogBrand] = useState<ICatalogBrandItem[]>([]);
	const [catalogType, setCatalogType] = useState<ICatalogTypeItem[]>([]);
	const [brandInputText, setBrandInputText] = useState<any>({invalid:null, value:''});
	const [typeInputText, setTypeInputText] = useState<any>({invalid:null, value:''});
	const [selectedFile, setSelectedFile] = useState(null);
	const [catalogInput, setCatalogInput] = useState<any> ({
		catalogBrandId : 1,
		catalogTypeId: 1,
		description: '',
		name: '',
		pictureFileName: '',
		price: 10,
		availableStock: 1});

	useEffect(() => {
		const getData = async () => {
			const cBrand = await getAllCatalogBrand();
			setCatalogBrand(cBrand);
			const cType = await getAllCatalogType();
			setCatalogType(cType);
			const catalogRes = await getAllCatalog();
			setCatalog(catalogRes);
		}
		getData();		   
  },[]);
	
	const handleAddNewBrand = async (e : any) => {
		setBrandInputText({...brandInputText, invalid: !brandInputText.value});		
		if(brandInputText.value)
		{
			const newBrand = await createCatalogBrand(brandInputText.value);
			setCatalogBrand([...catalogBrand, newBrand]);
		}		
	}

	const handleAddNewItemType = async (e : any) => {
		setTypeInputText({...typeInputText, invalid: !typeInputText.value});		
		if(typeInputText.value)
		{
			const newItemType = await createCatalogType(typeInputText.value);
			setCatalogType([...catalogType, newItemType]);
		}		
	}

	const handleAddNewCatalogItem = async (e : any) => {
		let valid = !!catalogInput.name && !!selectedFile;
		console.log(selectedFile);
		if(valid)
		{
			const newItem = await createCatalog(catalogInput);
			setCatalog([...catalog, newItem]);
		}
	}

	
	return (
		<div>
			<h1>Brands</h1>
			<Form>
				<FormGroup>					
          <Input invalid={brandInputText.invalid}  name="brand" id="brandInput" placeholder="New brand name" value={brandInputText.value} onChange={e => setBrandInputText({...brandInputText, value: e.target.value})} />
          <FormFeedback invalid >The brand name field is required</FormFeedback>					
				</FormGroup>
				<Button onClick={handleAddNewBrand}>Submit</Button>
			</Form>
			{
				catalogBrand && (
					<table className='table table-striped' aria-labelledby="tabelLabel">
						<thead>
							<tr>
								<th>Id</th>
								<th>Brand</th>								
							</tr>
						</thead>
						<tbody>
							{catalogBrand.map(brand =>
								<tr key={`brand-${brand.id}`}>
									<td>{brand.id}</td>
									<td>{brand.brand}</td>									
								</tr>
							)}
						</tbody>

					</table>
				)
			}
			<h1>Type</h1>
			<Form>
				<FormGroup>					
          <Input invalid={typeInputText.invalid}  name="type" id="typeInput" placeholder="New Type name" value={typeInputText.value} onChange={e => setTypeInputText({...typeInputText, value: e.target.value})} />
          <FormFeedback invalid >The item typefield is required</FormFeedback>					
				</FormGroup>
				<Button onClick={handleAddNewItemType}>Submit</Button>
			</Form>
			{
				catalogType && (
					<table className='table table-striped' aria-labelledby="tabelLabel">
						<thead>
							<tr>
								<th>Id</th>
								<th>Brand</th>								
							</tr>
						</thead>
						<tbody>
							{catalogType.map(type =>
								<tr key={`type-${type.id}`}>
									<td>{type.id}</td>
									<td>{type.type}</td>									
								</tr>
							)}
						</tbody>

					</table>
				)
			}

			<h1>Catalog</h1>
			{
				(catalogBrand && 	catalogType) && (
					<Form>
						<FormGroup>					
							<Input invalid={!catalogInput.name}  name="catalogName" id="catalogNameInput" placeholder="New name" value={catalogInput.name} onChange={e => setCatalogInput({...catalogInput, name: e.target.value})} />
							<FormFeedback invalid >The item name is required</FormFeedback>					
						</FormGroup>
						<FormGroup>
							<Input name="catalogDescription" id="catalogDescriptionInput" placeholder="Description" value={catalogInput.description} onChange={e => setCatalogInput({...catalogInput, description: e.target.value})} />							
						</FormGroup>
						<FormGroup>
							<Input type="select" name="catalogBrand" id="catalogBrandInput" value={catalogInput.catalogBrandId} onChange={e => setCatalogInput({...catalogInput, catalogBrandId: e.target.value})} >
								{
									catalogBrand.map(brand => <option key={`brand-option-${brand.id}`} value={brand.id}>{brand.brand}</option>)
								}
							</Input>											
						</FormGroup>
						<FormGroup>
							<Input type="select" name="catalogType" id="catalogTypeInput" value={catalogInput.catalogTypeId} onChange={e => setCatalogInput({...catalogInput, catalogTypeId: e.target.value})} >
								{
									catalogType.map(type => <option key={`type-option-${type.id}`} value={type.id}>{type.type}</option>)
								}
							</Input>											
						</FormGroup>
						<FormGroup>
							<Label for="catalogPriceInput">Price:</Label>
							<Input type='number' name="catalogPrice" id="catalogPriceInput" placeholder="Price" value={catalogInput.price} onChange={e => setCatalogInput({...catalogInput, price: e.target.value})} />							
						</FormGroup>
						<FormGroup>
							<Label for="catalogStockInput">Available Stock:</Label>
							<Input type='number' name="catalogStock" id="catalogStockInput" placeholder="Stock" value={catalogInput.availableStock} onChange={e => setCatalogInput({...catalogInput, availableStock: e.target.value})} />							
						</FormGroup>
						<FormGroup>
							<Input invalid={!selectedFile} type='file' name="catalogImage" id="catalogImageInput" accept="image/*" onChange={e => setSelectedFile(e.target.files[0])}  />
							<FormFeedback invalid >The image is required</FormFeedback>						
						</FormGroup>

					<Button onClick={handleAddNewCatalogItem}>Submit</Button>

					</Form>
				) 

			}
			{
				catalog && (
					<table className='table table-striped' aria-labelledby="tabelLabel">
						<thead>
							<tr>
								<th>Id</th>
								<th>Name</th>
								<th>Description</th>
								<th>Price</th>
								<th>Stock</th>
								<th>Brand</th>
								<th>Type</th>				
							</tr>
						</thead>
						<tbody>
							{catalog.map(item =>
								<tr key={`catalog-${item.id}`}>
									<td>{item.id}</td>
									<td>{item.name}</td>
									<td>{item.description}</td>
									<td>{item.price}</td>
									<td>{item.availableStock}</td>
									<td>{catalogBrand.find(brand => brand.id === item.catalogBrandId).brand}</td>
									<td>{catalogType.find(type => type.id === item.catalogTypeId).type}</td>								
								</tr>
							)}
						</tbody>

					</table>
				)
			}
		</div>
	);
}