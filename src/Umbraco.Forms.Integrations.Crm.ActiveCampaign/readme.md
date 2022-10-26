# Umbraco.Forms.Integrations.Crm.ActiveCampaign

This integration provides a custom workflow, allowing form entries to be mapped to an ActiveCampaign contact record, a contact's custom fields or to associate a contact with an existing CRM account.

## Prerequisites

Required minimum versions of Umbraco CMS: 
- CMS: 10.1.0
- Forms: 10.1.0

## How To Use

### Authentication

All requests to the ActiveCampaign API are authenticated by providing
an API key. The API key is included as an HTTP header called _Api-Token_.

If the configuration is incomplete, the user will receive an error message.

### Configuration

An ActiveCampaign contact has four main properties: email, first name, last name and phone.
To connect to your ActiveCampaign account, the following configuration is required:
```
"Umbraco": {
  "CMS": {
    "Integrations": {
        "Crm": {
          "ActiveCampaign": {
            "Settings": {
              "BaseUrl": "https://[YOUR_ACCOUNT_NAME].api-us1.com",
              "ApiKey": "[YOUR_API_KEY]",
              "ContactFields": [
                {
                  "name": "email",
                  "displayName": "Email",
                  "required": true
                },
                {
                  "name": "firstName",
                  "displayName": "First Name",
                  "required": false
                },
                {
                  "name": "lastName",
                  "displayName": "Last Name",
                  "required": false
                },
                {
                  "name": "phone",
                  "displayName": "Phone",
                  "required": true
                }
            ]
          }
        }
      }
    }
  }
}
```
Email property is mandatory by default through ActiveCampaign API rules. The
required rule can be extended to the other properties as well, by explicitly specifying that in the ```required```
property of each ```ContactFields``` node.


### Working with the Umbraco Forms - ActiveCampaign integration

To use it you will need to attach the _ActiveCampaign Contacts Workflow_ to a form, configure the mappings between the contact properties and the form fields,
select an account if you want to associate the contacts, and/or map any contact custom fields. 

When a form is submitted on the website, the workflow will execute and based on the provided email, create or update an ActiveCampaign account. If custom fields mappings 
have been provided, the contact payload will contain custom fields values.

After the account data has been persisted, if an account has been provided in the workflow setup, then an association with the account will be created.
