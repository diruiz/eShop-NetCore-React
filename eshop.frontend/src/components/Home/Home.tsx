import React, { useEffect, useState } from 'react';
import { ICatalog } from '../../models/catalog.model';
import { getPaginatedCatalog } from '../../services/catalog.service';
import './Home.css';
import Card from '../Card/Card';

export default function Home() {
	const [page, setPage] = useState<number>(0);
	const [limit, setLimit] = useState<number>(8);
	const [pagesNumber, setPagesNumber] = useState<number>(0);
	const [catalog, setCatalog] = useState<ICatalog | undefined>(undefined);

	useEffect(() => {
		const getData = async () => {
			const result = await getPaginatedCatalog(page,limit);
			setPagesNumber(Math.ceil(result.count/limit));
			setCatalog(result);
		}
		getData();		   
  },[page, limit]);
  
  return (
    <div>
      <h1>Welcome to my app</h1> 
	  	<div className="esh-catalog-items row">
				{
					(catalog && catalog?.count > 0) && catalog.items.map((item)=>{
						return (
							<div className="col-12 col-sm-6 col-md-4 col-lg-3">
								<Card item={item} />
							</div>
						);
					})
				}
				{pagesNumber}
				{JSON.stringify(catalog)} 
				
			</div>    
    </div>
  );
}