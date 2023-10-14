import { ICatalogBrandItem } from "../models/catalogBrand.model";
import getHttpOptions from "./getHttpOptions";


export async function getAllCatalogBrand()
{
	const options = getHttpOptions();
	const url = `${process.env.REACT_APP_API_ENDPOINT}/v1/CatalogBrand`;	
	const response = await fetch(url, options);
	if (!response.ok) {
			throw new Error(response.statusText);
	}

	const result = await response.json();	
	return result as ICatalogBrandItem[];
}

export async function createCatalogBrand(brand:string)
{
	const options = getHttpOptions('POST',{brand});
	const url = `${process.env.REACT_APP_API_ENDPOINT}/v1/CatalogBrand`;	
	const response = await fetch(url, options);
	if (!response.ok) {
			throw new Error(response.statusText);
	}

	const result = await response.json();	
	return result as ICatalogBrandItem;
}