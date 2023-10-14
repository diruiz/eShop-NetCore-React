import React from 'react';
import { Route, Routes } from "react-router-dom";
import { LoginCallback } from '@okta/okta-react';
import Home from "./components/Home/Home";
import ManageCatalog from "./components/ManageCatalog/ManageCatalog";
import { RequiredAuth } from "./components/common/RequiredAuth";
import Loading from "./components/common/Loading";

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" index={true} element={<Home/>}/>
      <Route path="login/callback" element={<LoginCallback loadingElement={<Loading/>}/>}/>
      <Route path="/catalog" element={<RequiredAuth/>}>
        <Route path="" element={<ManageCatalog/>}/>
      </Route>     
    </Routes>
  );
};



export default AppRoutes;