import { Fragment } from "react";

const FilterBar=(props)=>{
    return(
        <Fragment >
            <div className="div-inlineblock">
                <label>Filter By Type:</label>
                <select >
                    <option value="">All</option>
                    <option value="">Categories only</option>
                    <option value="">Items only</option>
                </select>
            </div>
            <div  className="div-inlineblock" >
                <label>Filter By Item Company:</label>
                <select >
                    <option value="">All</option>
                    <option value="">ItemCategories only</option>
                    <option value="">Items only</option>
                </select>
            </div>
        </Fragment>
    )
}
export default FilterBar;