import React from 'react';
import { Route, Routes } from 'react-router-dom';
import Layout from './components/Layout/Layout';
import AppRoutes from './AppRoutes';

function App() {
  return (
    <Layout>
      <Routes>
      {AppRoutes.map((route, index) => {
        const { element, ...rest } = route;
        return <Route key={index} {...rest} element={element} />;
      })}
      </Routes>      
    </Layout>
  );
}

export default App;
