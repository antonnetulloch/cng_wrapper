# cng_wrapper
A wrapper for Microsoft's Cryptography API, Next Generation CNG

Provides two methods Encrypt and Decrypt.

Sample usage:
  var cng = new CNGWrapper();
  var keyName = "LocalKeys";
  var encryptedString = cng.Encrypt(stringToEncrypt, keyName);
  
  var plainText = cng.Decrypt(encryptedString, keyName);
