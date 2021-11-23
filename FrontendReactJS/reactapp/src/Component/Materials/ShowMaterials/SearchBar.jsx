import { Fragment } from "react";

const SearchBar=(props)=>{
    return(
        <Fragment>
            <label>Search:</label>
            <input type="text" placeholder="search....."></input>
            <div className="div-inlineblock">
                <input id = "itemcategory-search" type="checkbox" value="value"   name = "itemcategory-search" />
                <span>Only in this Item Category</span>
            </div>
        </Fragment>

    )
}
export default SearchBar;