import { useOktaAuth } from '@okta/okta-react';
import React, { useEffect, useState } from 'react';
import { ICatalog, ICatalogItem } from '../../models/catalog.model';
import { getPaginatedCatalog } from '../../services/catalog.service';
import './Home.css';
import Card from '../Card/Card';
import { Pagination, PaginationItem, PaginationLink } from 'reactstrap';
import { IBasketItem } from '../../models/basket.model';
import { getBasketCache, setBasketCache } from '../../services/basket.service';

export default function Home() {
	const [currentPage, setCurrentPage] = useState<number>(0);
	const [limit, setLimit] = useState<number>(8);
	const [pagesCount, setPagesCount] = useState<number>(0);
	const [catalog, setCatalog] = useState<ICatalog | undefined>(undefined);
	const [basket, setBasket] = useState<IBasketItem[]>([]);
	const { authState, oktaAuth } = useOktaAuth();

	useEffect(() => {
		if (authState?.isAuthenticated){			
			getBasketCache().then(cacheBasket => {
				if(cacheBasket)
				{
					setBasket(cacheBasket);
				}
			});			
		}
	}, [authState, oktaAuth]); // Update if authState changes

	useEffect(() => {
		const getData = async () => {
			const result = await getPaginatedCatalog(currentPage, limit);
			setPagesCount(Math.ceil(result.count/limit));
			setCatalog(result);
		}
		getData();		   
  },[currentPage, limit]);

	function handlePagination(event: any, newPage: number){
		event.preventDefault();
		setCurrentPage(newPage);
	}

	function addToCart(item: ICatalogItem){
		if (!authState?.isAuthenticated){
			oktaAuth.signInWithRedirect();
		}
		const newBasket = [...basket];
		const existentItemIndex = basket.findIndex(b => b.id == item.id);
		if(existentItemIndex >= 0)
		{			
			newBasket[existentItemIndex].quantity ++;			
		}
		else{
			newBasket.push({...item, quantity:1 });
		}
		setBasketCache(newBasket);
		setBasket(newBasket);		
	}
  
  return (
    <div>
      <h1>Welcome to my app</h1> 
	  	<div className="esh-catalog-items row">
				{
					(catalog && catalog?.count > 0) && catalog.items.map((item, index)=>{
						return (
							<div key={`card-${index}`} className="col-12 col-sm-6 col-md-4 col-lg-3">
								<Card item={item} onClick={addToCart} />
							</div>
						);
					})
				}
			</div>
			<div>
				<Pagination aria-label="Page navigation">
					<PaginationItem disabled={currentPage <= 0}>
					<PaginationLink
                onClick={e => handlePagination(e, currentPage - 1)}
                previous
                href="#"
              />
					</PaginationItem>

					{[...Array(pagesCount)].map((page, index) => 
						<PaginationItem active={index === currentPage} key={`page-${index}`}>
							<PaginationLink onClick={e => handlePagination(e, index)} href="#">
								{index + 1}
							</PaginationLink>
						</PaginationItem>
          )}

					<PaginationItem disabled={currentPage >= pagesCount - 1}>              
						<PaginationLink
							onClick={e => handlePagination(e, currentPage + 1)}
							next
							href="#"
						/>              
					</PaginationItem>
				</Pagination>
			</div>    
    </div>
  );
}