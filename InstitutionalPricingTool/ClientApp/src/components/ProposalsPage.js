import React, { useState,useEffect } from "react";
import ReactTable from "react-table-v6";
import { getProposals } from "./interface";
import "react-table-v6/react-table.css";
import FacilitiesTable from "./FacilitiesTable"
import styles from "./Facilities.module.css";
import { Button } from "reactstrap";
 
function ProposalsPage() {
  const [proposalsList, setProposal] = useState([]);
  const [expanded, setExpanded] = useState([]);
  const[isFacilityExapanded,setIsFacilityExpanded] = useState(false);
  const columns = React.useMemo(
    () => [
      {
        Header: (
            <div className={styles.headerColumn}>Proposal Name</div>
        ),
        accessor: "proposalName",
      },
      {
        Header:(<div className={styles.headerColumn}>Customer Group</div>),
        accessor: "customerGrpName",
      },
      {
        Header: (
            <div className={styles.headerColumn}>Description</div>
        ),
        accessor: "description",
      },
      {
          id:"id",
          Header: (
            <div className={styles.headerColumn}>Date(last saved)</div>
        ),
          accessor: (d) => new Date(d.date).toLocaleDateString(),
      },
      {
        Header: (
            <div className={styles.headerColumn}>Status</div>
        ),
        accessor: "status",
      },{
        expander: true,
        width: 200,
        Expander: ({ isExpanded, ...rest }) =>
        {
            return (
              <div>
                {isExpanded
                  ? <Button style={{ backgroundColor: "#24a0ed" }} onClick={()=>{setIsFacilityExpanded(false)}}>Close Summary</Button>
                  : <Button style={{ backgroundColor: "#24a0ed" }} onClick={()=>{setIsFacilityExpanded(true)}}>View Summary</Button>
                }
              </div>
            );
          }
        }
    ],
    []
  );
  useEffect(() => {
    getProposals().then((result) => {
      setProposal(result);
    });
  }, []);
  const createSubComponet = (row) => {
    return (
      <FacilitiesTable proposalId={row.original.id}/>
    );
  };
  const rowIdentifier = (row) => row.original.id;

  const isExpanded = (row) => {
  return row.original.id === expanded
};

  return (
    <>
      {proposalsList && proposalsList.length>0 &&(
      <div style={{marginTop:"2rem"}}>
        <ReactTable columns={columns}
        data={proposalsList} 
        SubComponent={createSubComponet}
        expanderType="pencil"
        isInEditMode={isExpanded}
        isExpanded={isExpanded}
        rowIdentifier={rowIdentifier}
        expandable
        obeyDataStates
        />
      </div>
      )}
    </>
  );
}

export default ProposalsPage;
