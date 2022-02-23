import React from 'react';

const DaySelect=(props)=>{
    return(
        <select name='day' value={props.dateAccount.day} onChange={props.accountDateChanged}>
        {
            props.dayList.map((day,index)=>{return(<option key={index} value={day}>{day}</option>)})
        }
        </select>
    )
}
const MonthSelect=(props)=>{
    return(
        <select name='month' value={props.dateAccount.month} onChange={props.accountDateChanged}>
        {
            props.monthList.map((month,index)=>{return(<option key={index} value={index+1}>{month}</option>)})
        }
        </select>
    )
}
const YearSelect=(props)=>{
    return(
        <select name='year' value={props.dateAccount.year} onChange={props.accountDateChanged}>
        {
            props.yearList.map((year,index)=>{return(<option key={index} value={year}>{year}</option>)})
        }
        </select>
    )
}

const AccountSelector =(props)=>{
    const monthList = [ "January", "February", "March", "April", "May", "June",
            "July", "August", "September", "October", "November", "December" ];      
    const acountDateShift=async(value)=>{
        let day,month,year,minYear,maxYear;
        if(props.dateAccount.day!=null){
            const newdate=new Date(
                new Date(props.dateAccount.year,props.dateAccount.month-1,props.dateAccount.day).getTime()
                +value* 60 * 60 * 24 * 1000);
                
            day=newdate.getDate();
            month=newdate.getMonth()+1;
            year=newdate.getFullYear(); 
        }
        else if(props.dateAccount.month!=null){
            const newdate=new Date(props.dateAccount.year,props.dateAccount.month-1,1);
            newdate.setMonth(newdate.getMonth()+value);
            day=null;
            month=newdate.getMonth()+1;
            year=newdate.getFullYear();
        }
        else if(props.dateAccount.year!=null){
            day=null;
            month=null;
            year=props.dateAccount.year+value;
        }
        else {
            day=null;
            month=null;
            year=null;
            if(value<0){
                minYear=props.dateAccount.minYear-10;
                maxYear=props.dateAccount.maxYear-10;    
            }
            else{
                minYear=props.dateAccount.minYear+10;
                maxYear=props.dateAccount.maxYear+10;
            }
        }
        if(props.dateAccount.year!=null){
            if(year>props.dateAccount.maxYear){
                minYear=props.dateAccount.maxYear;
                maxYear=props.dateAccount.maxYear+10
            }
            else if(year<props.dateAccount.minYear){
                minYear=props.dateAccount.minYear-10;
                maxYear=props.dateAccount.minYear
            }
            else{
                minYear=props.dateAccount.minYear;
                maxYear=props.dateAccount.maxYear;
            }
        }
        props.acountDateSet({day:day,month:month,year:year,minYear:minYear,maxYear:maxYear});
    }
    const accountDateUP=()=>{
        if(props.dateAccount.day!=null){
            props.acountDateSet({day:null});
        }
        else if(props.dateAccount.month!=null){
            props.acountDateSet({month:null});
        }
        else if(props.dateAccount.year!=null){
            props.acountDateSet({year:null});
        }
        else return;
    }
    const accountDateChanged=(e)=>{
        if(e.target.name==='day'){
            props.acountDateSet({day:e.target.value});
        }
        else if(e.target.name==='month'){
            props.acountDateSet({month:e.target.value});
        }
        else if(e.target.name==='year'){
            props.acountDateSet({year:e.target.value});
        }
    }
    const arrayFromRange=(start,end)=>{
        let array=[];
        for(let i=start;i<=end;i++) array.push(i);
        return array;
    }
    const yearList=arrayFromRange(props.dateAccount.minYear,props.dateAccount.maxYear);  
    const AccountUpButton=<button className="btn-flat color-button radius" 
            style={{float:"right",marginTop:8}} onClick={accountDateUP}>
                    Account UP
            </button>;
    const AccountShiftRightButton=<button className="btn-flat color-button radius"
                            onClick={()=>acountDateShift(-1)}>&lt;</button>;
    const AccountShiftLeftButton=<button className="btn-flat color-button radius" style={{marginRight:5}}
                        onClick={()=>acountDateShift(1)}>&gt;</button>
    if(props.dateAccount.day!=null){
        let dayList=[];
        const dayscount=new Date(props.dateAccount.year,props.dateAccount.month,0).getDate();
        for(let i=1;i<dayscount;i++) dayList.push(i);

        return(
            <div className="standalone-div borderbuttom ">
                <label>Day Account:</label>
                <div className="div-inlineblock">
                    {AccountShiftRightButton}
                    <DaySelect dateAccount={props.dateAccount}
                        accountDateChanged={accountDateChanged} dayList={dayList}/>
                    {AccountShiftLeftButton}
                    <MonthSelect dateAccount={props.dateAccount} 
                    accountDateChanged={accountDateChanged} monthList={monthList}/>
                    <YearSelect dateAccount={props.dateAccount} 
                    accountDateChanged={accountDateChanged} yearList={yearList}/>    
                </div>
                {AccountUpButton}
            </div>    
        )
    }
    else if(props.dateAccount.month!=null){ 
        return(
            <div className="standalone-div borderbuttom ">
                <label>Month Account:</label>
                <div className="div-inlineblock">
                    {AccountShiftRightButton}
                    <MonthSelect dateAccount={props.dateAccount}
                        accountDateChanged={accountDateChanged} monthList={monthList}/>
                    {AccountShiftLeftButton}
                    <YearSelect dateAccount={props.dateAccount}
                        accountDateChanged={accountDateChanged} yearList={yearList}/>    
                </div>
                {AccountUpButton}
            </div> 
        )
    }
    else if(props.dateAccount.year!=null){
        return(
            <div className="standalone-div borderbuttom ">
                <label>Year Account:</label>
                <div className="div-inlineblock">
                    {AccountShiftRightButton}
                    <YearSelect  dateAccount={props.dateAccount} accountDateChanged={accountDateChanged} yearList={yearList}/>    
                    {AccountShiftLeftButton}
                </div>
                {AccountUpButton}
            </div> 
        )
    }
    else{
        return(
            <div className="standalone-div borderbuttom ">
                <label>Year Range Account:</label>
                <div className="div-inlineblock">
                    {AccountShiftRightButton}    
                    <label>{props.dateAccount.minYear+" - "+props.dateAccount.maxYear}</label>   
                    {AccountShiftLeftButton}
                </div>
                
            </div> 
        )
    }
    
};

export default AccountSelector;