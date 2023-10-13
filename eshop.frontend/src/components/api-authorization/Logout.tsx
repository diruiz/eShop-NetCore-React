import React, { useEffect, useState } from 'react'
import { ApplicationPaths, LogoutActions, QueryParameterNames } from './ApiAuthorizationConstants';
import authService, { AuthenticationResultStatus } from './AuthorizeService';

export default function Logout({action} : {action : string}) {
	const [message, setMessage] = useState<string | null | undefined>(undefined);
	const [isReady, setIsReady] = useState<boolean>(false);
	const [authenticated, setAuthenticated] = useState<boolean>(false);

	useEffect(() => {
		switch (action) {
			case LogoutActions.Logout:
				if (!!window.history.state.usr.local) {
					logout(getReturnUrl({}));
				} else {
					// This prevents regular links to <app>/authentication/logout from triggering a logout
					setMessage("The logout was not initiated from within the page.");
					setIsReady(true);
				}
				break;
			case LogoutActions.LogoutCallback:
				processLogoutCallback();
				break;
			case LogoutActions.LoggedOut:
				setMessage("You successfully logged out!");
				setIsReady(true);				
				break;
			default:
				throw new Error(`Invalid action '${action}'`);
		}	
		populateAuthenticationState();		   
  },[]);

	async function logout(returnUrl:any) {
		const state = { returnUrl };
		const isauthenticated = await authService.isAuthenticated();
		if (isauthenticated) {
			const result = await authService.signOut(state) as any;
			switch (result.status) {
				case AuthenticationResultStatus.Redirect:
					break;
				case AuthenticationResultStatus.Success:
					await navigateToReturnUrl(returnUrl);
					break;
				case AuthenticationResultStatus.Fail:
					setMessage(result.message);
					break;
				default:
					throw new Error("Invalid authentication result status.");
			}
		} else {
			setMessage("You successfully logged out!");			
		}
	}

	async function processLogoutCallback() {
		const url = window.location.href;
		const result = await authService.completeSignOut(url)as any;
		switch (result.status) {
			case AuthenticationResultStatus.Redirect:
				// There should not be any redirects as the only time completeAuthentication finishes
				// is when we are doing a redirect sign in flow.
				throw new Error('Should not redirect.');
			case AuthenticationResultStatus.Success:
				await navigateToReturnUrl(getReturnUrl(result.state));
				break;
			case AuthenticationResultStatus.Fail:
				setMessage(result.message);				
				break;
			default:
				throw new Error("Invalid authentication result status.");
		}
	}

	async function populateAuthenticationState() {
		const authenticated = await authService.isAuthenticated();
		setIsReady(true);
		setAuthenticated(authenticated);		
	}

	function getReturnUrl(state:any) {
		const params = new URLSearchParams(window.location.search);
		const fromQuery = params.get(QueryParameterNames.ReturnUrl);
		if (fromQuery && !fromQuery.startsWith(`${window.location.origin}/`)) {
			// This is an extra check to prevent open redirects.
			throw new Error("Invalid return url. The return url needs to have the same origin as the current page.")
		}
		return (state && state.returnUrl) ||
			fromQuery ||
			`${window.location.origin}${ApplicationPaths.LoggedOut}`;
	}

	function navigateToReturnUrl(returnUrl:string) {
		return window.location.replace(returnUrl);
	}

	function renderAction() {
		switch(action) {
			case LogoutActions.Logout:
				return (<div>Processing logout</div>);
			case LogoutActions.LogoutCallback:
				return (<div>Processing logout callback</div>);
			case LogoutActions.LoggedOut:
				return (<div>{message}</div>);
			default:
				throw new Error(`Invalid action '${action}'`);
		}
	}

	return (
		<>
			{ !isReady ? <div></div> : 
				(
					!!message ? <div>{message}</div> : renderAction ()
				)
			}
		</>
	);
}