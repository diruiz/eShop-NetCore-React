import React, { useEffect, useState } from 'react';
import { ApplicationPaths, LoginActions, QueryParameterNames } from './ApiAuthorizationConstants';
import authService, { AuthenticationResultStatus } from './AuthorizeService';

export default function Login({action} : {action : string}) {
	const [message, setMessage] = useState<string | null | undefined>(undefined);

	useEffect(() => {
		switch (action) {
			case LoginActions.Login:
				login(getReturnUrl({}));
				break;
			case LoginActions.LoginCallback:
				processLoginCallback();
				break;
			case LoginActions.LoginFailed:
				const params = new URLSearchParams(window.location.search);
				const error = params.get(QueryParameterNames.Message);
				setMessage(error)				
				break;
			case LoginActions.Profile:
				redirectToProfile();
				break;
			case LoginActions.Register:
				redirectToRegister();
				break;
			default:
				throw new Error(`Invalid action '${action}'`);
		}
			   
  },[]);

	async function login(returnUrl: string) {
		const state = { returnUrl };
		const result = await authService.signIn(state) as any;
		switch (result.status) {
			case AuthenticationResultStatus.Redirect:
				break;
			case AuthenticationResultStatus.Success:
				await navigateToReturnUrl(returnUrl);
				break;
			case AuthenticationResultStatus.Fail:
				setMessage(result.message)				
				break;
			default:
				throw new Error(`Invalid status result ${result.status}.`);
		}
	}

	function getReturnUrl(state: any) {
		const params = new URLSearchParams(window.location.search);
		const fromQuery = params.get(QueryParameterNames.ReturnUrl);
		if (fromQuery && !fromQuery.startsWith(`${window.location.origin}/`)) {
			// This is an extra check to prevent open redirects.
			throw new Error("Invalid return url. The return url needs to have the same origin as the current page.")
		}

		const returnUrl = (state && state.returnUrl) || fromQuery || `${window.location.origin}/`;
		
		return returnUrl as string;
	}

	function navigateToReturnUrl(returnUrl: string) {
		// It's important that we do a replace here so that we remove the callback uri with the
		// fragment containing the tokens from the browser history.
		window.location.replace(returnUrl);
	}

	async function processLoginCallback() {
		const url = window.location.href;
		const result = await authService.completeSignIn(url) as any;
		switch (result.status) {
			case AuthenticationResultStatus.Redirect:
				// There should not be any redirects as the only time completeSignIn finishes
				// is when we are doing a redirect sign in flow.
				throw new Error('Should not redirect.');
			case AuthenticationResultStatus.Success:
				await navigateToReturnUrl(getReturnUrl(result.state));
				break;
			case AuthenticationResultStatus.Fail:
				setMessage(result.message)				
				break;
			default:
				throw new Error(`Invalid authentication result status '${result.status}'.`);
		}
	}

	function redirectToRegister() {
		redirectToApiAuthorizationPath(`${ApplicationPaths.IdentityRegisterPath}?${QueryParameterNames.ReturnUrl}=${encodeURI(ApplicationPaths.Login)}`);
	}
	
	function redirectToProfile() {
		redirectToApiAuthorizationPath(ApplicationPaths.IdentityManagePath);
	}
	
	function redirectToApiAuthorizationPath(apiAuthorizationPath:string) {
		const redirectUrl = `${window.location.origin}/${apiAuthorizationPath}`;
		// It's important that we do a replace here so that when the user hits the back arrow on the
		// browser they get sent back to where it was on the app instead of to an endpoint on this
		// component.
		window.location.replace(redirectUrl);
	}

	function renderAction() {
		switch(action) {
			case LoginActions.Login:
				return (<div>Processing login</div>);
			case LoginActions.LoginCallback:
				return (<div>Processing login callback</div>);
			case LoginActions.Profile:
			case LoginActions.Register:
				return (<div></div>);
			default:
				throw new Error(`Invalid action '${action}'`);
		}
	}

  return (
    <>
			{ !!message ? <div>message</div> : renderAction()	}      
    </>
  );
}