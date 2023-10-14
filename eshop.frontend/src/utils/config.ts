const CLIENT_ID = process.env.REACT_APP_CLIENT_ID;
const ISSUER = process.env.REACT_APP_ISSUER;
const OKTA_TESTING_DISABLEHTTPSCHECK = process.env.REACT_APP_OKTA_TESTING_DISABLEHTTPSCHECK;
const REDIRECT_URI = `${window.location.origin}/login/callback`;

const config = {
	clientId : CLIENT_ID,
	issuer: ISSUER,
	redirectUri: REDIRECT_URI,
	scopes: ['openid', 'profile', 'email'],
	pkce: true,
	disableHttpsCheck: OKTA_TESTING_DISABLEHTTPSCHECK
};

export default config;
