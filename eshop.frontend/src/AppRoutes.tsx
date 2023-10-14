import Home from "./components/Home/Home";
import LoginCallback from "./components/LoginCallback/LoginCallback";
import ApiAuthorizationRoutes from "./components/api-authorization/ApiAuthorizationRoutes";

const AppRoutes = [
	{
		index: true,
		element: <Home />
	},
	{
		path: "auth-login-callback",
		element: <LoginCallback />
	},
	...ApiAuthorizationRoutes    
];

export default AppRoutes;