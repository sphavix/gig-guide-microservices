import { Fragment, useEffect, useState } from 'react'
import { Container } from 'semantic-ui-react';
import { Gig } from '../models/gig';
import NavBar from './NavBar';
import GigsDashboard from '../../features/gigs/dashboard/GigsDashboard';
import {v4 as uuid} from 'uuid';
import agent from '../api/agent';
import LoadingComponent from './LoadingComponent';

function App() {
  const [gigs, setGigs] = useState<Gig[]>([]);

  // Use State to set selected gig. Then set it down through the details and dashboard.
  const [selectedGig, setSelectedGig] = useState<Gig | undefined>(undefined); //use union type undefined or Gig.

  // Use State to the component when Editing and item
  const [editMode, setEditMode] = useState(false);

  // set state for loading and delay
  const [loading, setLoading] = useState(true);


  useEffect(() => {
    agent.Gigs.list()
        .then(response => {
          let gigs: Gig[] = [];
          response.forEach(gig => {
            gig.date = gig.date.split('T')[0]; // Exclude the time info taking the first split of the date info
            gigs.push(gig);
          })
          setGigs(response);
          setLoading(false);
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

  if(loading) return <LoadingComponent content='Loading App' />

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
