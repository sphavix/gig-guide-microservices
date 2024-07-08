import { Fragment, useEffect, useState } from 'react'
import axios from 'axios';
import { Container, Header, List } from 'semantic-ui-react';
import { Gig } from '../models/gig';
import NavBar from './NavBar';
import GigsDashboard from '../../features/gigs/dashboard/GigsDashboard';

function App() {
  const [gigs, setGigs] = useState<Gig[]>([]);

  useEffect(() => {
    axios.get<Gig[]>('http://localhost:5001/api/gigs/getallgigs')
        .then(respons => {
          setGigs(respons.data)
        })
  }, [])

  return (
    <Fragment>
      <NavBar />
        <Container style={{marginTop: '7em'}}>
          <GigsDashboard gigs={gigs} />
        </Container>
    </Fragment>
  )
}

export default App
