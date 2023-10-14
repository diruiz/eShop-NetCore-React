import { ICatalog, ICatalogItem } from "../models/catalog.model";
import getHttpOptions from "./getHttpOptions";

export async function getPaginatedCatalog(page: number, limit: number)
{
	const options = getHttpOptions();
	const url = `${process.env.REACT_APP_API_ENDPOINT}/v1/Catalog?page=${page}&limit=${limit}`;	
	const response = await fetch(url, options);
	if (!response.ok) {
			throw new Error(response.statusText);
	}

	const result = await response.json();	
	return result as ICatalog;
}

export async function getAllCatalog()
{
	const options = getHttpOptions();
	const url = `${process.env.REACT_APP_API_ENDPOINT}/v1/Catalog/All`;	
	const response = await fetch(url, options);
	if (!response.ok) {
			throw new Error(response.statusText);
	}

	const result = await response.json();	
	return result as ICatalogItem[];
}