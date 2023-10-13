import React from 'react';
import { Container } from 'reactstrap';

export default function Layout({children} : {children : any}) {
  return (
    <div>
      <h1>Welcome to my app</h1>
      <Container>
        {children}
      </Container>
    </div>
  );
}