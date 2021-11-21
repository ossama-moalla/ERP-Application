import { Field, Formik,Form } from 'formik';
import React, { Component } from 'react';

class AddItemCategoryFormik extends Component {
    constructor(props){
        super(props);
        this.state={
            ParentID:null,
            name:'',
            defaultConsumeUnit:''
        }
    }
    form=()=>{
        return(
        <Form className="form-group">
            <label>ItemCategory Name</label>
            <Field className="form-control"  name="name"></Field>
            <label>Default Consume Unit</label>
            <Field className="form-control"  name="defaultConsumeUnit"></Field>
            <button className="btn btn-primary" style={{margin:5}} className="btn btn-primary" type="submit">Add</button>
        </Form>)
    }
    onSubmit=(values)=>{
        console.log(values)
    }
    render() {
        return (
            <div >
                <Formik initialValues={{name:'',ParentID:null,defaultConsumeUnit:''}}
                        onSubmit={this.onSubmit}
                        
                        >
                    {this.form}                     
                </Formik>
            </div>
        );
    }
}

export default AddItemCategoryFormik;