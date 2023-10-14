import { useOktaAuth } from '@okta/okta-react';
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { Navbar, NavbarBrand, NavbarToggler, Collapse, NavItem, NavLink } from 'reactstrap';
import './NavMenu.css';

export default function NavMenu() {
	const [collapsed, setCollapsed] = useState(true);
	const { authState, oktaAuth } = useOktaAuth();

	const login = async () => oktaAuth.signInWithRedirect();
  const logout = async () => oktaAuth.signOut();
	const toggleNavbar = () => setCollapsed(!collapsed);
	
	if (!authState) {
    return null;
  }
	debugger;

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