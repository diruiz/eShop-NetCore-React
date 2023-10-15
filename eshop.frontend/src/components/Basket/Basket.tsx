import React from 'react';
import { IBasketItem } from '../../models/basket.model';

export default function Basket(basket: IBasketItem[]) {	
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
							</tr>
						</thead>
						<tbody>
							{basket.map(item =>
								<tr key={`basket-${item.id}`}>									
									<td>{item.name}</td>									
									<td>{item.price}</td>
									<td>{item.quantity}</td>
									<td><img className="esh-basket-thumbnail" src={item.pictureFileName} alt={item.name}/></td>																
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