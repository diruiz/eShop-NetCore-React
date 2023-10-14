import React, { useEffect, useState } from 'react';
import authService from './AuthorizeService';
import { NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { ApplicationPaths } from './ApiAuthorizationConstants';

function authenticatedView(userName:string, profilePath:string, logoutPath:string, logoutState:any) {
  return (
		<>
			<NavItem>
				<NavLink tag={Link} className="text-dark" to={profilePath}>Hello {userName}</NavLink>
			</NavItem>
			<NavItem>
				<NavLink replace tag={Link} className="text-dark" to={logoutPath} state={logoutState}>Logout</NavLink>
			</NavItem>
  	</>
	);
}

function anonymousView(registerPath:string, loginPath:string) {
	debugger;
  return (
		<>
			<NavItem>
				<NavLink tag={Link} className="text-dark" to={registerPath}>Register</NavLink>
			</NavItem>
			<NavItem>
				<NavLink tag={Link} className="text-dark" to={loginPath}>Login</NavLink>
			</NavItem>
		</>
	);
}

export default function LoginMenu() {
	const [userName, setUserName] = useState<string>("");
	const [authenticated, setAuthenticated] = useState<boolean>(false);
	let _subscription: any;
	debugger;

	useEffect(() => {
    _subscription = authService.subscribe(() => populateState());
		populateState();
    return () => {
      authService.unsubscribe(_subscription);
    };
  }, []);

	async function populateState() {
		const [isAuthenticated, user] = await Promise.all([authService.isAuthenticated(), authService.getUser()])
		setAuthenticated(isAuthenticated);
		setUserName(user && user.name);		
	}

	return(
		<>
			{
				!authenticated ? anonymousView(ApplicationPaths.Register, ApplicationPaths.Login) :
				authenticatedView(userName, ApplicationPaths.Profile, ApplicationPaths.LogOut, { local: true })
			}
		</>
	);
}