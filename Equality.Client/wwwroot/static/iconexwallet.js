window.request_address_async = () => {
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
                console.log(payload);
            }
        });
};
window.request_signing_async = (from, hash) => {
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
window.request_has_account_async = () => {
    window.dispatchEvent(new CustomEvent('ICONEX_RELAY_REQUEST',
        {
            detail: {
                type: 'REQUEST_HAS_ACCOUNT'
            }
        }));
};