window.request_signing = (from, hash) => {
    window.dispatchEvent(new CustomEvent('ICONEX_RELAY_REQUEST',
        {
            detail: {
                type: 'REQUEST_SIGNING', 
                payload: { 
                    from: from,
                    hash: hash
                }
            }
        }));
};
window.request_has_account = () => {
    window.dispatchEvent(new CustomEvent('ICONEX_RELAY_REQUEST',
        {
            detail: {
                type: 'REQUEST_HAS_ACCOUNT'
            }
        }));
};
window.request_address = dotnetref => {
    window.dispatchEvent(new CustomEvent('ICONEX_RELAY_REQUEST',
        {
            detail: {
                type: 'REQUEST_ADDRESS'
            }
        }));
    window.addEventListener('ICONEX_RELAY_RESPONSE',
        e => {
            const { type, payload } = e.detail;
            if (type === 'RESPONSE_ADDRESS') {
                dotnetref.invokeMethodAsync('ResponseAddressAsync', payload);
            }
        });
};