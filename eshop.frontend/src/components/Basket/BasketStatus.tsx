import React from 'react';
import { IBasketItem } from '../../models/basket.model';
import cart from '../../assets/images/cart.svg'
import './BasketStatus.css'

export default function BasketStatus({badge, onClick}: {badge: number, onClick:any}) {	
	return(
		<div className='esh-basketstatus-container' onClick={e => onClick(e)}>
			<a className="esh-basketstatus pt-2 pb-2">   
				<div className="esh-basketstatus-image ml-4 mr-1">
					<img src={cart} alt="cart" />
				</div>
				<div className="esh-basketstatus-badge">
					{badge}
				</div>
			</a>
		</div>
		
	)
}