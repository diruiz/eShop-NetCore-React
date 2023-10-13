import React, { useEffect, useState } from 'react';
import { ICatalog } from '../models/catalog.model';
import { getPaginatedCatalog } from '../services/catalog.service';

export default function Home() {
	const [page, setPage] = useState<number>(0);
	const [limit, setLimit] = useState<number>(10);
	const [pagesNumber, setPagesNumber] = useState<number>(0);
	const [catalog, setCatalog] = useState<ICatalog | undefined>(undefined);

	useEffect(() => {
		const getData = async () => {
			const result = await getPaginatedCatalog(page,limit);
			setPagesNumber(Math.ceil(result.count/limit));
			setCatalog(result);
		}
		getData();		   
  },[]);
  
  return (
    <div>
      <h1>Welcome to my app</h1> 
			{pagesNumber}
			{JSON.stringify(catalog)}     
    </div>
  );
}