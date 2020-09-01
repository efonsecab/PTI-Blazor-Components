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
            DotNet.invokeMethodAsync(onApproveFunctionAssembly, onApproveFunctionName, data, actions);
        }
    }).render(elementId);
}