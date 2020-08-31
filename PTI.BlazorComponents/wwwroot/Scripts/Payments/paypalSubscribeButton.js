function RenderPaypalButton(elementId, planId, onApproveFunction) {
    debugger;
    paypal.Buttons({
        style: {
            shape: 'pill',
            color: 'blue',
            layout: 'horizontal',
            label: 'subscribe',
            tagline: true
        },
        createSubscription: function (data, actions) {
            return actions.subscription.create({
                'plan_id': planId
            });
        },
        onApprove: window[onApproveFunction]
        //onApprove: function (data, actions) {
        //    alert(data.subscriptionID);
        //}
    }).render(elementId);
}