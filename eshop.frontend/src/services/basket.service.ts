import { IBasketItem } from "../models/basket.model";
import getHttpOptions from "./getHttpOptions";

export async function getBasketCache()
{
	const options = getHttpOptions();
	const url = `${process.env.REACT_APP_API_ENDPOINT}/v1/Basket`;	
	const response = await fetch(url, options);
	if (!response.ok) {
			throw new Error(response.statusText);
	}
	if(response.status == 200 )
	{
		const result = await response.json();	
		return result as IBasketItem[];
	}
	else{
		return [];
	}	
}

export async function setBasketCache(basket : IBasketItem[])
{
	const options = getHttpOptions('POST', basket);
	const url = `${process.env.REACT_APP_API_ENDPOINT}/v1/Basket`;	
	const response = await fetch(url, options);
	if (!response.ok) {
		throw new Error(response.statusText);
	}
}