export interface ICatalog {
	count: number;
	items: ICatalogItem[];
}

export interface ICatalogItem{
	id: number,
	catalogBrandId : number,
	catalogTypeId: number,
	description: string,
	name: string,
	pictureFileName: string,
	price: number,
	availableStock: number
} 
