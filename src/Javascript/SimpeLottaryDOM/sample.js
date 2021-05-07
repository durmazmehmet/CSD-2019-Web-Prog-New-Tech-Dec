function init()
{
    var head = document.getElementsByTagName("head")[0];
    var script = document.createElement("script");
    var curScript = document.getElementsByTagName("script")[0];

    script.src = "lottary.js";

    head.insertBefore(script, curScript);
}

function playGame()
{
    var lotto = new NumericLotto();

    document.write(lotto.getColumn());
    //...
}
