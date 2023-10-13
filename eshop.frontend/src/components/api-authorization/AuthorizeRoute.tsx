import React, { useEffect, useState } from 'react';
import authService from './AuthorizeService';
import { ApplicationPaths, QueryParameterNames } from './ApiAuthorizationConstants';
import { Navigate } from 'react-router-dom';

export default function AuthorizeRoute({path, element} : {path : string, element: any}) {
	const [isReady, setIsReady] = useState<boolean>(false);
	const [authenticated, setAuthenticated] = useState<boolean>(false);
	let _subscription: any;

	useEffect(() => {
    _subscription = authService.subscribe(() => authenticationChanged());
    return () => {
      authService.unsubscribe(_subscription);
    };
  }, []);

	async function populateAuthenticationState() {
		const authenticated = await authService.isAuthenticated();		
		setIsReady(true);
		setAuthenticated(authenticated);
	}
	
	async function authenticationChanged() {		
		setIsReady(false);
		setAuthenticated(false);
		await populateAuthenticationState();
	}

	function render(){
		var link = document.createElement("a");
		link.href = path;
		const returnUrl = `${link.protocol}//${link.host}${link.pathname}${link.search}${link.hash}`;
		const redirectUrl = `${ApplicationPaths.Login}?${QueryParameterNames.ReturnUrl}=${encodeURIComponent(returnUrl)}`;
		if (!isReady) {
			return <div></div>;
		} else {			
			return authenticated ? element : <Navigate replace to={redirectUrl} />;
		}	
	}

	return(
		<>
			{ render() }
		</>
	);
}