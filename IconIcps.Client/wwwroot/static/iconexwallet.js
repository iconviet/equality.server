window.request_address = () => {
    window.dispatchEvent(new CustomEvent('ICONEX_RELAY_REQUEST',
        {
            detail: {
                type: 'REQUEST_ADDRESS'
            }
        }));
};
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