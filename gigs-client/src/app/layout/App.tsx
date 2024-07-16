import { Fragment, useEffect, useState } from 'react'
import axios from 'axios';
import { Container, Header, List } from 'semantic-ui-react';
import { Gig } from '../models/gig';
import NavBar from './NavBar';
import GigsDashboard from '../../features/gigs/dashboard/GigsDashboard';

function App() {
  const [gigs, setGigs] = useState<Gig[]>([]);

  // Use State to set selected gig. Then set it down through the details and dashboard.
  const [selectedGig, setSelectedGig] = useState<Gig | undefined>(undefined); //use union type undefined or Gig.

  useEffect(() => {
    axios.get<Gig[]>('http://localhost:5001/api/gigs/getallgigs')
        .then(respons => {
          setGigs(respons.data)
        })
  }, [])

  function handleSelectedGig(id: string) {
    setSelectedGig(gigs.find(g => g.id === id));
  }

  function handleCancelSelectedGig(){
    setSelectedGig(undefined);
  }

  return (
    <Fragment>
      <NavBar />
        <Container style={{marginTop: '7em'}}>
          <GigsDashboard gigs={gigs}
          selectedGig={selectedGig}
          selectGig={handleSelectedGig}
          cancelSelectGig={handleCancelSelectedGig} />
        </Container>
    </Fragment>
  )
}

export default App
