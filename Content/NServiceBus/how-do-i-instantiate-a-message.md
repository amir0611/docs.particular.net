<!--
title: "How to Instantiate a Message?"
tags: ""
summary: "<div class="brush:csharp;"> If the message is a class"
-->

<div class="brush:csharp;"> If the message is a class


    var msg = new MyMessage();

OR if your message is an interface:

    var msg = Bus.CreateInstance();


