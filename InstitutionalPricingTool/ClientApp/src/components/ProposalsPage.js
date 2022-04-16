import React, { useState,useEffect } from "react";
import ReactTable, { RowInfo } from "react-table";
import Table from "./Table";
import { getProposals } from "./interface";


function ProposalsPage() {
  const [proposalsList, setProposal] = useState([]);
  const columns = React.useMemo(
    () => [
      {
        Header: "Proposal Name",
        accessor: "proposalName",
      },
      {
        Header: "Customer Group",
        accessor: "customerGrpName",
      },
      {
        Header: "Description",
        accessor: "description",
      },
      {
          Header:"Date(last saved)",
          accessor:"date"
      },
      {
        Header: "Status",
        accessor: "status",
      }
    ],
    []
  );
  useEffect(() => {
    getProposals().then((result) => {
      console.log("proposals", result);
      setProposal(result);
    });
  }, []);

  return (
    <>
      <h1>Hello React!</h1>
      {proposalsList && proposalsList.length>0 &&(
      <div>
        <Table columns={columns} data={proposalsList} />
      </div>
      )}
    </>
  );
}

export default ProposalsPage;
