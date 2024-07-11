import React from 'react';
import { Grid, List } from 'semantic-ui-react';
import { Gig } from '../../../app/models/gig';
import GigsList from './GigsList';
import GigDetails from '../details/GigDetails';
import GigForm from '../form/GigForm';

interface Props {
    gigs: Gig[];
}

//destructure or overload the function with properties
export default function GigsDashboard({gigs}: Props) {
    return (
        <Grid>
            <Grid.Column width='10'>
                <GigsList gigs={gigs} />
            </Grid.Column>

            <Grid.Column width='6'>
                {gigs[0] &&
               <GigDetails gig={gigs[0]} />}
               <GigForm />
            </Grid.Column>
        </Grid>
    )
}