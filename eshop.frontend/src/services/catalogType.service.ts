import { ICatalogTypeItem } from "../models/catalogType.model";
import getHttpOptions from "./getHttpOptions";


export async function getAllCatalogType()
{
	const options = getHttpOptions();
	const url = `${process.env.REACT_APP_API_ENDPOINT}/v1/CatalogType`;	
	const response = await fetch(url, options);
	if (!response.ok) {
			throw new Error(response.statusText);
	}

	const result = await response.json();	
	return result as ICatalogTypeItem[];
}