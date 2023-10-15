import React from 'react';
import { IBasketItem } from '../../models/basket.model';
import './Basket.css';
import deleteImg from '../../assets/images/delete.svg';

export default function Basket({ basket, removeItem }: { basket : IBasketItem[], removeItem:any}) {	
	return(
		<div>
			{
				basket && (
					<table className='table table-striped' aria-labelledby="tabelLabel">
						<thead>
							<tr>								
								<th>Name</th>								
								<th>Price</th>
								<th>Quantity</th>
								<th>image</th>
								<th>Delete</th>				
							</tr>
						</thead>
						<tbody>
							{basket.map(item =>
								<tr key={`basket-${item.id}`}>									
									<td>{item.name}</td>									
									<td>{item.price}</td>
									<td>{item.quantity}</td>
									<td><img className="esh-basket-thumbnail" src={item.pictureFileName} alt={item.name}/></td>	
									<td><img src={deleteImg} alt="delete" onClick={e => removeItem(item)}></img></td>														
								</tr>
							)}
							<tr>
								<td><b>Total:</b></td>
								<td>{basket.reduce((accumulator, currentValue) => accumulator + (currentValue.price*currentValue.quantity), 0)}</td>
							</tr>
						</tbody>
						
					</table>
				)
			}

		</div>
	);
}