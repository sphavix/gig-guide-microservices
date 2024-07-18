import { Fragment, useEffect, useState } from 'react'
import axios from 'axios';
import { Container } from 'semantic-ui-react';
import { Gig } from '../models/gig';
import NavBar from './NavBar';
import GigsDashboard from '../../features/gigs/dashboard/GigsDashboard';
import {v4 as uuid} from 'uuid';

function App() {
  const [gigs, setGigs] = useState<Gig[]>([]);

  // Use State to set selected gig. Then set it down through the details and dashboard.
  const [selectedGig, setSelectedGig] = useState<Gig | undefined>(undefined); //use union type undefined or Gig.

  // Use State to the component when Editing and item
  const [editMode, setEditMode] = useState(false);


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

  function handleFormOpen(id: string){
    id ? handleSelectedGig(id) : handleCancelSelectedGig();
    setEditMode(true);
  }

  function handleFormClose(){
    setEditMode(false);
  }

  function handleCreateOrEditGig(gig: Gig){
    gig.id ? setGigs([...gigs.filter(g => g.id !== gig.id), gig]) : setGigs([...gigs, {...gig, id: uuid()}]);
    setEditMode(false);
    setSelectedGig(gig);
  }

  function handleDeleteGig(id: string){
    setGigs([...gigs.filter(g => g.id !== id)]);
  }

  return (
    <Fragment>
      <NavBar openForm={handleFormOpen} />
        <Container style={{marginTop: '7em'}}>
          <GigsDashboard gigs={gigs}
          selectedGig={selectedGig}
          selectGig={handleSelectedGig}
          cancelSelectGig={handleCancelSelectedGig} 
          editMode={editMode}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          createOrEditGig={handleCreateOrEditGig}
          deleteGig={handleDeleteGig}
          
          />
        </Container>
    </Fragment>
  )
}

export default App
