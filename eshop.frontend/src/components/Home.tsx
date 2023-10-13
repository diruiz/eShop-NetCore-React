import React, { useEffect, useState } from 'react';
import { ICatalog } from '../models/catalog.model';
import { getPaginatedCatalog } from '../services/catalog.service';

export default function Home() {
	const [catalog, setCatalog] = useState<ICatalog | undefined>(undefined);

	useEffect(() => {
		const getData = async () => {
			const result = await getPaginatedCatalog(0,2);
			console.log(result);
		}
		getData();		   
  },[]);
  
  return (
    <div>
      <h1>Welcome to my app</h1>      
    </div>
  );
}