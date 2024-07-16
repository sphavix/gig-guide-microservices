import React from 'react';
import { Grid, List } from 'semantic-ui-react';
import { Gig } from '../../../app/models/gig';
import GigsList from './GigsList';
import GigDetails from '../details/GigDetails';
import GigForm from '../form/GigForm';

interface Props {
    gigs: Gig[];
    selectedGig: Gig | undefined;
    selectGig: (id: string) => void;
    cancelSelectGig: () => void;
}

//destructure or overload the function with properties
export default function GigsDashboard({gigs, selectedGig, selectGig, 
    cancelSelectGig}: Props) {
    return (
        <Grid>
            <Grid.Column width='10'>
                <GigsList gigs={gigs} selectGig={selectGig} />
            </Grid.Column>

            <Grid.Column width='6'>
                {selectedGig &&
               <GigDetails gig={selectedGig} cancelSelectGig={cancelSelectGig} />}
               <GigForm />
            </Grid.Column>
        </Grid>
    )
}