import React from 'react';
import { ICatalogItem } from '../../models/catalog.model';
import './Card.css';

export default function Card({item} : {item : ICatalogItem}) {
  return (
		<div className="esh-catalog-item">
			<div className="esh-catalog-thumbnail-wrapper">
				<div className="esh-catalog-thumbnail-icon d-flex justify-content-center">
					<img className="esh-catalog-thumbnail-icon-svg" src="assets/images/add.svg" />
				</div>
				<img className="esh-catalog-thumbnail" src={item.pictureFileName} />
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