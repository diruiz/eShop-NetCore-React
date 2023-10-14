export const ApplicationName = 'eShop';

export const QueryParameterNames = {
  ReturnUrl: 'returnUrl',
  Message: 'message'
};

export const LogoutActions = {
  LogoutCallback: 'logout-callback',
  Logout: 'logout',
  LoggedOut: 'logged-out'
};

export const LoginActions = {
  Login: 'login',
  LoginCallback: 'login-callback',
  LoginFailed: 'login-failed',
  Profile: 'profile',
  Register: 'register'
};

const prefix = '/authentication';

export const ApplicationPaths = {
  DefaultLoginRedirectPath: '/',
  ApiAuthorizationClientConfigurationUrl: `${process.env.REACT_APP_IDENTITY_SERVER_ENDPOINT}/_configuration/${ApplicationName}`,
  ApiAuthorizationPrefix: prefix,
  Login: `${prefix}/${LoginActions.Login}`,
  LoginFailed: `${process.env.REACT_APP_FRONTEND_ENDPOINT}/${LoginActions.LoginFailed}`,
  LoginCallback: `${process.env.REACT_APP_FRONTEND_ENDPOINT}/${LoginActions.LoginCallback}`,
  Register: `${prefix}/${LoginActions.Register}`,
  Profile: `${prefix}/${LoginActions.Profile}`,
  LogOut: `${prefix}/${LogoutActions.Logout}`,
  LoggedOut: `${prefix}/${LogoutActions.LoggedOut}`,
  LogOutCallback: `${prefix}/${LogoutActions.LogoutCallback}`,
  IdentityRegisterPath: `${process.env.REACT_APP_IDENTITY_SERVER_ENDPOINT}/Identity/Account/Register`,
  IdentityManagePath: `${process.env.REACT_APP_IDENTITY_SERVER_ENDPOINT}/Identity/Account/Manage`
};
