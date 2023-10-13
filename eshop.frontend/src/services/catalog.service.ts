import { ICatalog } from "../models/catalog.model";

export async function getPaginatedCatalog(page: number, limit: number)
{
	const url = `${process.env.REACT_APP_API_ENDPOINT}/v1/Catalog?page=${page}&limit=${limit}`;
	console.log(url);
	const response = await fetch(url);
	if (!response.ok) {
			throw new Error(response.statusText);
	}

	const result = await response.json();	
	return result as ICatalog;
}