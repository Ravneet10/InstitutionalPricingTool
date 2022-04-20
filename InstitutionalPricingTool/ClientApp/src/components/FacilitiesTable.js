import React, { useState, useEffect } from "react";
import { getFacilities } from "./interface";
import "react-table-v6/react-table.css";
import styles from "./Facilities.module.css";
import { DropdownMenu, DropdownItem, UncontrolledDropdown , DropdownToggle} from "reactstrap";

function FacilitiesTable(props) {
  const [facilitiesList, setFacilities] = useState([]);
  const [selectedFacility, setSelectedFacility] = useState(null);
  const [dropDownValue, setDropDownValue] = useState("Select Option");

  useEffect(() => {
    getFacilities(props.proposalId).then((result) => {
      setFacilities(result);
      if(result && result.length>0){
        setSelectedFacility(result[0]);
        setDropDownValue(result[0].facilityName);
      }
    });
  }, []);
const onMenuChange=(selectedFacility)=>{
    setDropDownValue(selectedFacility.facilityName);
    setSelectedFacility(selectedFacility);
}
  return (
    <>
      {facilitiesList && facilitiesList.length > 0 && (
        <table>
            <tr>
          <th>
              Facility
            <UncontrolledDropdown className={styles.dropdownParent} >
              <DropdownToggle caret size="sm" className={styles.dropdownToggle}>{dropDownValue}</DropdownToggle>
              <DropdownMenu> {facilitiesList.map((option, index) => <DropdownItem key={option.id} 
              onClick={()=>onMenuChange(option)}>{option.facilityName}</DropdownItem>)}
              </DropdownMenu>
            </UncontrolledDropdown>
          </th>
          </tr>
          <tr className={styles.flexRowDiv}>
            <td className={styles.flexColumnDiv}>
                <span>Booking Country</span>
                <span>{selectedFacility && selectedFacility.bookingCountry}</span>
            </td>
            <td className={styles.flexColumnDiv}>Currency 
            <span>{selectedFacility && selectedFacility.currency}</span>
            </td>
            <td className={styles.flexColumnDiv}>Limit
            <span>{selectedFacility && selectedFacility.limit.toFixed(2)}</span>
            </td>
            <td className={styles.flexColumnDiv}>Start Date
            <span>{selectedFacility != null ? new Date(selectedFacility.startDate).toLocaleDateString():""}</span>
            </td>
          </tr>
          <tr>
            <td className={styles.flexColumnDiv}>Maturity Date
            <span>{selectedFacility != null ? new Date(selectedFacility.maturityDate).toLocaleDateString():""}</span>
            </td>
          </tr>
        </table>
      )}
    </>
  );
}

export default FacilitiesTable;
