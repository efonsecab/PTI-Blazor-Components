function RenderPaypalButton(elementId, planId, onApproveFunctionAssembly, onApproveFunctionName) {
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
        onApprove: function (data, actions)
        {
            debugger;
            DotNet.invokeMethodAsync(onApproveFunctionAssembly, onApproveFunctionName, data, actions);
        }
        //onApprove: function (data, actions) {
        //    alert(data.subscriptionID);
        //}
    }).render(elementId);
}