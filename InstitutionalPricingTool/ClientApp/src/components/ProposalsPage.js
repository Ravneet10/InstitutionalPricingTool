import React, { useState, useEffect } from "react";
import ReactTable from "react-table-v6";
import { getProposals } from "./interface";
import "react-table-v6/react-table.css";
import FacilitiesTable from "./FacilitiesTable";
import styles from "./Facilities.module.css";
import { Button } from "reactstrap";

function ProposalsPage() {
  const [proposalsList, setProposal] = useState([]);
  const [errorMessage, seterrorMessage] = useState(null);
  const [isLoading, setIsLoading] = useState(false);
  const columns = React.useMemo(
    () => [
      {
        Header: <div className={styles.headerColumn}>Proposal Name</div>,
        accessor: "proposalName",
      },
      {
        Header: <div className={styles.headerColumn}>Customer Group</div>,
        accessor: "customerGrpName",
      },

      {
        id: "id",
        Header: <div className={styles.headerColumn}>Date (last saved)</div>,
        accessor: (d) =>
          new Date(d.date).toLocaleDateString("en-us", {
            day: "numeric",
            year: "numeric",
            month: "short",
          }),
      },
      {
        Header: <div className={styles.headerColumn}>Description</div>,
        width: 200,
        accessor: "description",
      },
      {
        Header: <div className={styles.headerColumn}>Status</div>,
        accessor: "status",
      },
      {
        expander: true,
        width: 200,
        Expander: ({ isExpanded, ...rest }) => {
          return (
            <div>
              {isExpanded ? (
                <Button className={styles.btnAsLink}>CLOSE SUMMARY</Button>
              ) : (
                <Button className={styles.btnAsLink}>VIEW SUMMARY</Button>
              )}
            </div>
          );
        },
      },
    ],
    []
  );
  useEffect(() => {
    setIsLoading(true);
    getProposals()
      .then((result) => {
        setIsLoading(false);
        setProposal(result);
      })
      .catch((x) => {
        seterrorMessage(x);
        setIsLoading(true);
      });
  }, []);
  const createSubComponet = (row) => {
    return <FacilitiesTable proposalId={row.original.id} />;
  };
  const rowIdentifier = (row) => row.original.id;

  return (
    <>
      {errorMessage != null && <div>Some Error Occurred</div>}
      {isLoading && <div>Loading in progress ...</div>}
      {!isLoading && proposalsList && proposalsList.length > 0 && (
        <div style={{ marginTop: "2rem" }}>
          <ReactTable
            className={styles.reactTableProposal}
            columns={columns}
            data={proposalsList}
            SubComponent={createSubComponet}
            expanderType="pencil"
            rowIdentifier={rowIdentifier}
            expandable
            obeyDataStates
            defaultPageSize={5}
            showPagination={false}
          />
        </div>
      )}
    </>
  );
}

export default ProposalsPage;
