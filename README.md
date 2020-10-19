FireTV Remote
==================
A simple application which allows to connect via adb to a FireTV device and send via "adb input keyevents <id>" different inputs.

Keys that are mapped:

Enter -> Enter/Select (Broken at the moment, I will try to fix it but I'm lazy)

Escape -> Back

Arrow Keys -> Up, Down, Left, Right


This is not a remote for everyday usage, since it is very slow (adb).

Instructions For Use
==================
1. Enable ADB Debugging on your FireTV device
        - https://developer.amazon.com/docs/fire-tv/connecting-adb-to-device.html

2. Put the IP Address of your FireTV device followed by :5555 in the "Enter IP Address" box (ex. 10.0.0.10:5555)
        - http://www.aftvnews.com/how-to-determine-the-ip-address-of-an-amazon-fire-tv-or-fire-tv-stick/

3. Use the remote as normal
