import React, { useEffect, useState } from 'react';
import { ICatalogBrandItem } from '../../models/catalogBrand.model';
import { ICatalogTypeItem } from '../../models/catalogType.model';
import { getAllCatalogBrand } from '../../services/catalogBrand.service';
import { getAllCatalogType } from '../../services/catalogType.service';

export default function ManageCatalog() {
	const [catalogBrand, setCatalogBrand] = useState<ICatalogBrandItem[]>([]);
	const [catalogType, setCatalogType] = useState<ICatalogTypeItem[]>([]);

	useEffect(() => {
		const getData = async () => {
			const cBrand = await getAllCatalogBrand();
			setCatalogBrand(cBrand);
			const cType = await getAllCatalogType();
			setCatalogType(cType);
		}
		getData();		   
  },[]);	

	return (
		<div>
			<h1>Brands</h1>
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
		</div>
	);
}