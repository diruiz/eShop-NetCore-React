import React from 'react';
import { Route, Routes, useNavigate } from 'react-router-dom';
import Layout from './components/Layout/Layout';
import AppRoutes from './AppRoutes';
import { OktaAuth, toRelativeUrl } from '@okta/okta-auth-js';
import config from './utils/config';
import { Security } from '@okta/okta-react';

const oktaAuth = new OktaAuth(config);

function App() {  
  const navigate = useNavigate();
  const restoreOriginalUri = (oktaAuth:OktaAuth,  originalUri:string) => {
    navigate(toRelativeUrl(originalUri || '/', window.location.origin));
  };
  return (
    <Security oktaAuth={oktaAuth} restoreOriginalUri={restoreOriginalUri}>
      <Layout>
        <AppRoutes />           
      </Layout>
    </Security>
  );
}

export default App;
