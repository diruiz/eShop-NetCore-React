import React from 'react';
import { ICatalogItem } from '../../models/catalog.model';
import './Card.css';
import addItem from '../../assets/images/add.svg'

interface CardProps {
	item: ICatalogItem;
	onClick: (item: ICatalogItem) => void;	
}

export default function Card({item, onClick} : CardProps) {
  return (
		<div className="esh-catalog-item" onClick={e => onClick(item)}>
			<div className="esh-catalog-thumbnail-wrapper">
				<div className="esh-catalog-thumbnail-icon d-flex justify-content-center">
					<img className="esh-catalog-thumbnail-icon-svg" src={addItem} alt="Add to cart" />
				</div>
				<img className="esh-catalog-thumbnail" alt={item.name} src={item.pictureFileName} />
			</div>
			<div className="esh-catalog-details d-flex justify-content-between align-items-center">
				<div className="esh-catalog-name ml-3">
					<span>{item.name}</span>
				</div>
				<div className="esh-catalog-price mr-3">
					<span>{item.price}</span>
				</div>
			</div>
		</div>
  );
}