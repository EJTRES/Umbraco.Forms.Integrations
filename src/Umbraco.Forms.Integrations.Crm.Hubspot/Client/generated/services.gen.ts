// This file is auto-generated by @hey-api/openapi-ts

import type { CancelablePromise } from './core/CancelablePromise';
import { OpenAPI } from './core/OpenAPI';
import { request as __request } from './core/request';
import type { IsAuthorizationConfiguredResponse, GetAuthenticationUrlResponse, AuthorizeData, AuthorizeResponse, DeauthorizeResponse, GetAllResponse, GetFormFieldsData, GetFormFieldsResponse } from './types.gen';

export class ContactsService {
    /**
     * @returns string OK
     * @throws ApiError
     */
    public static isAuthorizationConfigured(): CancelablePromise<IsAuthorizationConfiguredResponse> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/umbraco/hubspot/management/api/v1/contacts/auth/configured'
        });
    }
    
    /**
     * @returns string OK
     * @throws ApiError
     */
    public static getAuthenticationUrl(): CancelablePromise<GetAuthenticationUrlResponse> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/umbraco/hubspot/management/api/v1/contacts/auth/url'
        });
    }
    
    /**
     * @param data The data for the request.
     * @param data.requestBody
     * @returns unknown OK
     * @throws ApiError
     */
    public static authorize(data: AuthorizeData = {}): CancelablePromise<AuthorizeResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/umbraco/hubspot/management/api/v1/contacts/authorize',
            body: data.requestBody,
            mediaType: 'application/json'
        });
    }
    
    /**
     * @returns unknown OK
     * @throws ApiError
     */
    public static deauthorize(): CancelablePromise<DeauthorizeResponse> {
        return __request(OpenAPI, {
            method: 'POST',
            url: '/umbraco/hubspot/management/api/v1/contacts/deauthorize'
        });
    }
    
    /**
     * @returns unknown OK
     * @throws ApiError
     */
    public static getAll(): CancelablePromise<GetAllResponse> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/umbraco/hubspot/management/api/v1/contacts/properties'
        });
    }
    
}

export class FormsService {
    /**
     * @param data The data for the request.
     * @param data.formId
     * @returns unknown OK
     * @throws ApiError
     */
    public static getFormFields(data: GetFormFieldsData = {}): CancelablePromise<GetFormFieldsResponse> {
        return __request(OpenAPI, {
            method: 'GET',
            url: '/umbraco/hubspot/management/api/v1/forms/fields',
            query: {
                formId: data.formId
            }
        });
    }
    
}