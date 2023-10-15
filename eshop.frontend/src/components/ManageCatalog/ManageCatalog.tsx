import React, { useEffect, useState } from 'react';
import { ICatalogBrandItem } from '../../models/catalogBrand.model';
import { ICatalogTypeItem } from '../../models/catalogType.model';
import { createCatalogBrand, getAllCatalogBrand } from '../../services/catalogBrand.service';
import { createCatalogType, getAllCatalogType } from '../../services/catalogType.service';
import { ICatalogItem } from '../../models/catalog.model';
import { getAllCatalog } from '../../services/catalog.service';
import { Button, Form, FormFeedback, FormGroup, Input, Label } from 'reactstrap';

export default function ManageCatalog() {
	const [catalog, setCatalog] = useState<ICatalogItem[]>([]);
	const [catalogBrand, setCatalogBrand] = useState<ICatalogBrandItem[]>([]);
	const [catalogType, setCatalogType] = useState<ICatalogTypeItem[]>([]);
	const [brandInputText, setBrandInputText] = useState<any>({invalid:null, value:''});
	const [typeInputText, setTypeInputText] = useState<any>({invalid:null, value:''});

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
							<Input invalid={typeInputText.invalid}  name="catalogName" id="catalogNameInput" placeholder="New Type name" value={typeInputText.value} onChange={e => setTypeInputText({...typeInputText, value: e.target.value})} />
							<FormFeedback invalid >The item is required</FormFeedback>					
					</FormGroup>
					<Button onClick={handleAddNewItemType}>Submit</Button>

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