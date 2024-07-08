import React from "react";
import { Card } from "semantic-ui-react";
import { Gig } from "../../../app/models/gig";

interface Props{
    gig: Gig
}


export default function GigDetails({gig}: Props){
    return (
       <Card>
            <Image src={`/assets/categoryImages/${gig.category}.jpg`} width='10px' />
       </Card>
    )
}