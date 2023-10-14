import { useOktaAuth } from '@okta/okta-react';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import { Navbar, NavbarBrand, NavbarToggler, Collapse, NavItem, NavLink } from 'reactstrap';
import './NavMenu.css';

export default function NavMenu() {
	const [collapsed, setCollapsed] = useState(true);
	const [userInfo, setUserInfo] = useState(null);
	const { authState, oktaAuth } = useOktaAuth();

	useEffect(() => {
		if (!authState?.isAuthenticated) {
			// When user isn't authenticated, forget any user info
			setUserInfo(null);
		} else {
			oktaAuth.getUser().then((info) => {
				setUserInfo(info);
				console.log(info);
			});
		}
	}, [authState, oktaAuth]); // Update if authState changes

	const login = async () => oktaAuth.signInWithRedirect();
  const logout = async () => oktaAuth.signOut();
	const toggleNavbar = () => setCollapsed(!collapsed);
	
	if (!authState) {
    return null;
  }	

	return (
		<header>        
			<Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" container light>
				<NavbarBrand tag={Link} to="/">eShop</NavbarBrand>
				<NavbarToggler onClick={toggleNavbar} className="mr-2" />
				<Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={collapsed} navbar>
					<ul className="navbar-nav flex-grow">
						<NavItem>
							<NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
						</NavItem>
						{ authState.isAuthenticated && (
							<NavItem>
								<NavLink tag={Link} className="text-dark" to="/catalog" >Manage Catalog</NavLink>
							</NavItem>
						)}
						{ authState.isAuthenticated && (
							<NavItem>
								<NavLink tag={Link} className="text-dark" to="/profile" >{userInfo?.name}</NavLink>
							</NavItem>
						)}
						{ authState.isAuthenticated && (
							<NavItem>
								<NavLink tag={Link} className="text-dark" onClick={logout} >Logout</NavLink>
							</NavItem>
						)}
						{ authState && !authState.isAuthenticated && (
							<NavItem>
								<NavLink tag={Link} className="text-dark" onClick={login} >Login</NavLink>
							</NavItem>
						)}
					</ul>
				</Collapse>
			</Navbar>
		</header>
	);
}